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

  deleteTask(id) {
    this._lsWorker.deleteTask(id);
  }
}

export default TaskLsWorker;
