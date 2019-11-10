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
    await this._worker.addTask(task);
  }

  async getTasks() {
    return await this._worker.getTasks();
  }

  async deleteTask(id) {
    await this._worker.deleteTask(id);
  }
}

export default TaskWorker;
