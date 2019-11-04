import LocalStorageWorker from "./LocalStorageWorker";

class TaskLsWorker {
  constructor() {
    this._lsWorker = new LocalStorageWorker();
  }

  addTask(task) {
    this._lsWorker.addTask(task);
  }

  getTasks() {
    return this._lsWorker.getTasks();
  }
}

export default TaskLsWorker;
