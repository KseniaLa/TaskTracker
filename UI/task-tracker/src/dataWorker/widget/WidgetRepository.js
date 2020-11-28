import WidgetContext from "./WidgetContext";
import WidgetWorkerFactory from "./WidgetWorkerFactory";

let singleton = Symbol();
let singletonEnforcer = Symbol();

class WidgetRepository {
  constructor(enforcer) {
    if (enforcer !== singletonEnforcer)
      throw "Instantiation failed: cannot create singleton with new";

    this._context = new WidgetContext();
    this._factory = new WidgetWorkerFactory();
  }

  static get instance() {
    if (!this[singleton])
      this[singleton] = new WidgetRepository(singletonEnforcer);
    return this[singleton];
  }

  static set instance(v) {
    throw "Cannot change property";
  }

  async addWidget(isDemo, widget, authToken) {
    let worker = this._factory.getWorker(isDemo);
    this._context.setWorker(worker);
    return await this._context.addWidget(widget, authToken);
  }

  async getWidgets(isDemo, token) {
    let worker = this._factory.getWorker(isDemo);
    this._context.setWorker(worker);
    return await this._context.getWidgets(token);
  }

  async deleteWidget(isDemo, id, authToken) {
    let worker = this._factory.getWorker(isDemo);
    this._context.setWorker(worker);
    return await this._context.deleteWidget(id, authToken);
  }
}

export default WidgetRepository;
