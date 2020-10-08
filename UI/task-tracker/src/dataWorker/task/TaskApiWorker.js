import ApiWorker from "../common/ApiWorker";

class TaskApiWorker {
  constructor() {
    this._apiWorker = new ApiWorker();
  }

  async addTask(task) {
    return await this._apiWorker.addTask(task);
  }

  async getTasks(token) {
    return await this._apiWorker.getTasks(token);
  }

  async deleteTask(id) {
    return await this._apiWorker.deleteTask(id);
  }
}

export default TaskApiWorker;
