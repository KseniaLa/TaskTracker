class TaskWorker {
  constructor() {
    this._worker = null;
  }

  set worker(worker) {
    this._worker = worker;
  }

  get worker() {
    return this._worker;
  }

  addTask() {
    this._worker.addTask();
  }
}

export default TaskWorker;
