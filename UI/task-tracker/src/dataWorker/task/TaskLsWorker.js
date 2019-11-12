import LocalStorageWorker from "../common/LocalStorageWorker";

class TaskLsWorker {
  constructor() {
    this._lsWorker = new LocalStorageWorker();
  }

  async addTask(task) {
    return await this._lsWorker.addTask(task);
  }

  async getTasks() {
    return await this._lsWorker.getTasks();
  }

  async deleteTask(id) {
    return await this._lsWorker.deleteTask(id);
  }
}

export default TaskLsWorker;
