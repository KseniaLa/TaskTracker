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

  async addTask(task, token) {
    return await this._worker.addTask(task, token);
  }

  async getTasks(token) {
    return await this._worker.getTasks(token);
  }

  async deleteTask(id, token) {
    return await this._worker.deleteTask(id, token);
  }
}

export default TaskWorker;
