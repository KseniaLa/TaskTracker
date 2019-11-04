import ApiWorker from "./ApiWorker";

class TaskApiWorker {
  constructor() {
    this._apiWorker = new ApiWorker();
  }

  addTask() {
    this._apiWorker.addTask();
  }

  getTasks() {
    return this._apiWorker.getTasks();
  }

  deleteTask() {
    this._apiWorker.deleteTask();
  }
}

export default TaskApiWorker;
