import ApiWorker from "../common/ApiWorker";

class WidgetApiWorker {
  constructor() {
    this._apiWorker = new ApiWorker();
  }

  async addWidget(task) {
    await this._apiWorker.addWidget(task);
  }

  async getWidgets() {
    return await this._apiWorker.getWidgets();
  }

  deleteWidget() {
    this._apiWorker.deleteWidget();
  }
}

export default WidgetApiWorker;
