class WidgetContext {
  constructor() {
    this._worker = new Object();
  }

  setWorker(worker) {
    this._worker = worker;
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

export default WidgetContext;
