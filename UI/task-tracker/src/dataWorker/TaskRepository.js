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

  addTask(isDemo) {
    let worker = this._factory.getWorker(isDemo);
    this._context.setWorker(worker);
    this._context.addTask();
  }
}

export default TaskRepository;
