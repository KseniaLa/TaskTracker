import ApiWorker from "../common/ApiWorker";

class WidgetApiWorker {
  constructor() {
    this._apiWorker = new ApiWorker();
  }

  async addWidget(task, authToken) {
    return await this._apiWorker.addWidget(task, authToken);
  }

  async getWidgets(token) {
    return await this._apiWorker.getWidgets(token);
  }

  async deleteWidget(id, authToken) {
    return await this._apiWorker.deleteWidget(id, authToken);
  }
}

export default WidgetApiWorker;
