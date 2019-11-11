import LocalStorageWorker from "../common/LocalStorageWorker";

class WidgetLsWorker {
  constructor() {
    this._lsWorker = new LocalStorageWorker();
  }

  async addWidget(widget) {
    await this._lsWorker.addWidget(widget);
  }

  async getWidgets() {
    return await this._lsWorker.getWidgets();
  }

  async deleteWidget(id) {
    await this._lsWorker.deleteWidget(id);
  }
}

export default WidgetLsWorker;
