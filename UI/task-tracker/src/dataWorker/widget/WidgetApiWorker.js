import ApiWorker from "../common/ApiWorker";

class WidgetApiWorker {
  constructor() {
    this._apiWorker = new ApiWorker();
  }

  addWidget() {
    this._apiWorker.addWidget();
  }

  getWidgets() {
    return this._apiWorker.getWidgets();
  }

  deleteWidget() {
    this._apiWorker.deleteWidget();
  }
}

export default WidgetApiWorker;
