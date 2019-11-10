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

  async addWidget(isDemo, widget) {
    //console.log(isDemo)
    //console.log(widget)
    let worker = this._factory.getWorker(isDemo);
    this._context.setWorker(worker);
    await this._context.addWidget(widget);
  }

  async getWidgets(isDemo) {
    let worker = this._factory.getWorker(isDemo);
    this._context.setWorker(worker);
    return await this._context.getWidgets();
  }

  deleteWidget(isDemo, id) {
    let worker = this._factory.getWorker(isDemo);
    this._context.setWorker(worker);
    return this._context.deleteWidget(id);
  }
}

export default WidgetRepository;
