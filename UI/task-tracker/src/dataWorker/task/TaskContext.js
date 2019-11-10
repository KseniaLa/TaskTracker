class TaskContext {
  constructor() {
    this._worker = new Object();
  }

  setWorker(worker) {
    this._worker = worker;
  }

  async addTask(task) {
    await this._worker.addTask(task);
  }

  async getTasks() {
    return await this._worker.getTasks();
  }

  async deleteTask(id) {
    await this._worker.deleteTask(id);
  }
}

export default TaskContext;
