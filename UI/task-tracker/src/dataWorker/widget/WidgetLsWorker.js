import LocalStorageWorker from "../common/LocalStorageWorker";

class WidgetLsWorker {
  constructor() {
    this._lsWorker = new LocalStorageWorker();
  }

  async addWidget(widget) {
    return await this._lsWorker.addWidget(widget);
  }

  async getWidgets(token) {
    return await this._lsWorker.getWidgets(token);
  }

  async deleteWidget(id) {
    return await this._lsWorker.deleteWidget(id);
  }
}

export default WidgetLsWorker;
