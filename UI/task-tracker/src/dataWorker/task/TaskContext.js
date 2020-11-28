class TaskContext {
  constructor() {
    this._worker = new Object();
  }

  setWorker(worker) {
    this._worker = worker;
  }

  async addTask(task, authToken) {
    return await this._worker.addTask(task, authToken);
  }

  async getTasks(token) {
    return await this._worker.getTasks(token);
  }

  async deleteTask(id, authToken) {
    return await this._worker.deleteTask(id, authToken);
  }
}

export default TaskContext;
