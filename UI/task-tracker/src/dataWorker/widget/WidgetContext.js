class WidgetContext {
  constructor() {
    this._worker = new Object();
  }

  setWorker(worker) {
    this._worker = worker;
  }

  async addWidget(widget) {
    return await this._worker.addWidget(widget);
  }

  async getWidgets() {
    return await this._worker.getWidgets();
  }

  async deleteWidget(id) {
    return await this._worker.deleteWidget(id);
  }
}

export default WidgetContext;
