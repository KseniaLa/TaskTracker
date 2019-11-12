import ApiWorker from "../common/ApiWorker";

class TaskApiWorker {
  constructor() {
    this._apiWorker = new ApiWorker();
  }

  async addTask(task) {
    return await this._apiWorker.addTask(task);
  }

  async getTasks() {
    return await this._apiWorker.getTasks();
  }

  async deleteTask(id) {
    return await this._apiWorker.deleteTask(id);
  }
}

export default TaskApiWorker;
