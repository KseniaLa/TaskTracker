class WidgetContext {
  constructor() {
    this._worker = new Object();
  }

  setWorker(worker) {
    this._worker = worker;
  }

  addWidget(task) {
    this._worker.addWidget(task);
  }

  getWidgets() {
    return this._worker.getWidgets();
  }

  deleteWidget(id) {
    this._worker.deleteWidget(id);
  }
}

export default WidgetContext;
