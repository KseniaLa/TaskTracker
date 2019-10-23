import LocalStorageWorker from "./LocalStorageWorker";

class TaskLsWorker {
  constructor() {
    this._lsWorker = new LocalStorageWorker();
  }

  addTask() {
    this._lsWorker.addTask();
  }
}

export default TaskLsWorker;
