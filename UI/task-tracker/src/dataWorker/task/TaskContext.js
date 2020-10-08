class TaskContext {
  constructor() {
    this._worker = new Object();
  }

  setWorker(worker) {
    this._worker = worker;
  }

  async addTask(task) {
    return await this._worker.addTask(task);
  }

  async getTasks(token) {
    return await this._worker.getTasks(token);
  }

  async deleteTask(id) {
    return await this._worker.deleteTask(id);
  }
}

export default TaskContext;
