class WidgetWorker {
  constructor() {
    this._worker = null;
  }

  set worker(worker) {
    this._worker = worker;
  }

  get worker() {
    return this._worker;
  }

  async addWidget(widget) {
    return await this._worker.addWidget(widget);
  }

  async getWidgets(token) {
    return await this._worker.getWidgets(token);
  }

  async deleteWidget(id) {
    return await this._worker.deleteWidget(id);
  }
}

export default WidgetWorker;
