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

export default TaskWorker;
