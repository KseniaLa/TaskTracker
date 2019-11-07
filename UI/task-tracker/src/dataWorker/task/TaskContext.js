class TaskContext {
  constructor() {
    this._worker = new Object();
  }

  setWorker(worker) {
    this._worker = worker;
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

export default TaskContext;