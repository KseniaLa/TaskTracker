import LocalStorageWorker from "../common/LocalStorageWorker";

class WidgetLsWorker {
  constructor() {
    this._lsWorker = new LocalStorageWorker();
  }

  addWidget(widget) {
    this._lsWorker.addWidget(widget);
  }

  getWidgets() {
    return this._lsWorker.getWidgets();
  }

  deleteWidget(id) {
    this._lsWorker.deleteWidget(id);
  }
}

export default WidgetLsWorker;
