import ApiWorker from "./ApiWorker";

class TaskApiWorker {
  constructor() {
    this._apiWorker = new ApiWorker();
  }

  addTask() {
    this._apiWorker.addTask();
  }
}

export default TaskApiWorker;
