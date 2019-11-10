import ApiWorker from "../common/ApiWorker";

class WidgetApiWorker {
  constructor() {
    this._apiWorker = new ApiWorker();
  }

  addWidget() {
    this._apiWorker.addWidget();
  }

  async getWidgets() {
    return await this._apiWorker.getWidgets();
  }

  deleteWidget() {
    this._apiWorker.deleteWidget();
  }
}

export default WidgetApiWorker;
