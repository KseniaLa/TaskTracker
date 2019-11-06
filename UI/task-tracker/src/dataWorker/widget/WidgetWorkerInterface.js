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

  addWidget(widget) {
    this._worker.addWidget(widget);
  }

  getWidgets() {
    return this._worker.getWidgets();
  }

  deleteWidget(id) {
    this._worker.deleteWidget(id);
  }
}

export default WidgetWorker;
