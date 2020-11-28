import TaskContext from "./TaskContext";
import TaskWorkerFactory from "./TaskWorkerFactory";

let singleton = Symbol();
let singletonEnforcer = Symbol();

class TaskRepository {
  constructor(enforcer) {
    if (enforcer !== singletonEnforcer)
      throw "Instantiation failed: cannot create singleton with new";

    this._context = new TaskContext();
    this._factory = new TaskWorkerFactory();
  }

  static get instance() {
    if (!this[singleton])
      this[singleton] = new TaskRepository(singletonEnforcer);
    return this[singleton];
  }

  static set instance(v) {
    throw "Cannot change property";
  }

  async addTask(isDemo, task, token) {
    let worker = this._factory.getWorker(isDemo);
    this._context.setWorker(worker);
    return await this._context.addTask(task, token);
  }

  async getTasks(isDemo, token) {
    let worker = this._factory.getWorker(isDemo);
    this._context.setWorker(worker);
    return await this._context.getTasks(token);
  }

  async deleteTask(isDemo, id, token) {
    let worker = this._factory.getWorker(isDemo);
    this._context.setWorker(worker);
    return await this._context.deleteTask(id, token);
  }
}

export default TaskRepository;
