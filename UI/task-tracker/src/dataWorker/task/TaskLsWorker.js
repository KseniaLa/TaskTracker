import LocalStorageWorker from "../common/LocalStorageWorker";

class TaskLsWorker {
  constructor() {
    this._lsWorker = new LocalStorageWorker();
  }

  addTask(task) {
    this._lsWorker.addTask(task);
  }

  async getTasks() {
    return await this._lsWorker.getTasks();
  }

  deleteTask(id) {
    this._lsWorker.deleteTask(id);
  }
}

export default TaskLsWorker;
