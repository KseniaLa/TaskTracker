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

  addTask(task) {
    this._worker.addTask(task);
  }

  getTasks() {
    return this._worker.getTasks();
  }

  deleteTask(id) {
    this._worker.deleteTask(id);
  }
}

export default TaskWorker;
