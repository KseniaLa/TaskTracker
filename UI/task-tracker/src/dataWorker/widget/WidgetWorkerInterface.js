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

  async addWidget(widget, authToken) {
    return await this._worker.addWidget(widget, authToken);
  }

  async getWidgets(token) {
    return await this._worker.getWidgets(token);
  }

  async deleteWidget(id, authToken) {
    return await this._worker.deleteWidget(id, authToken);
  }
}

export default WidgetWorker;
