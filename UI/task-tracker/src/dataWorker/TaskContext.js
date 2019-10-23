class TaskContext {
  constructor() {
    this._worker = new Object();
  }

  setWorker(worker) {
    this._worker = worker;
  }

  addTask() {
    this._worker.addTask();
  }
}

export default TaskContext;
