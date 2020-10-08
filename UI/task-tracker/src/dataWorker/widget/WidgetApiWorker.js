import ApiWorker from "../common/ApiWorker";

class WidgetApiWorker {
  constructor() {
    this._apiWorker = new ApiWorker();
  }

  async addWidget(task) {
    return await this._apiWorker.addWidget(task);
  }

  async getWidgets(token) {
    return await this._apiWorker.getWidgets(token);
  }

  async deleteWidget(id) {
    return await this._apiWorker.deleteWidget(id);
  }
}

export default WidgetApiWorker;
