import ApiWorker from "../common/ApiWorker";

class TaskApiWorker {
  constructor() {
    this._apiWorker = new ApiWorker();
  }

  async addTask(task, authToken) {
    return await this._apiWorker.addTask(task, authToken);
  }

  async getTasks(token) {
    return await this._apiWorker.getTasks(token);
  }

  async deleteTask(id, authToken) {
    return await this._apiWorker.deleteTask(id, authToken);
  }
}

export default TaskApiWorker;
