import ApiWorker from "../common/ApiWorker";

class TaskApiWorker {
  constructor() {
    this._apiWorker = new ApiWorker();
  }

  async addTask(task) {
    await this._apiWorker.addTask(task);
  }

  async getTasks() {
    return await this._apiWorker.getTasks();
  }

  async deleteTask(id) {
    await this._apiWorker.deleteTask(id);
  }
}

export default TaskApiWorker;
