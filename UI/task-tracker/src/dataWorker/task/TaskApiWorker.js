import ApiWorker from "../common/ApiWorker";

class TaskApiWorker {
  constructor() {
    this._apiWorker = new ApiWorker();
  }

  addTask() {
    this._apiWorker.addTask();
  }

  async getTasks() {
    return await this._apiWorker.getTasks();
  }

  deleteTask() {
    this._apiWorker.deleteTask();
  }
}

export default TaskApiWorker;
