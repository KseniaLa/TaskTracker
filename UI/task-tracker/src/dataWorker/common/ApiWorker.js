import axios from "axios";

class ApiWorker {
  constructor() {}

  async addTask(task) {
    let data = JSON.stringify(task);

    let result = null;
    try {
      result = await axios.post("http://localhost:52779/api/task/add", data, {
        headers: {
          "Content-Type": "application/json"
        }
      });
    } catch {
      return false;
    }

    if (result.status === 200) {
      return true;
    } else {
      return false;
    }
  }

  async getTasks() {
    let result = null;
    try {
      result = await axios.get("http://localhost:52779/api/task");
    } catch {
      return [];
    }

    return result.data.tasks;
  }

  async deleteTask(id) {
    let result = null;
    try {
      result = await axios.delete(
        `http://localhost:52779/api/task/delete/${id}`
      );
    } catch {
      return false;
    }

    if (result.status === 200) {
      return true;
    } else {
      return false;
    }
  }

  async getWidgets() {
    let result = await axios.get("http://localhost:52779/api/widget");
    return result.data.widgets;
  }

  async addWidget(widget) {
    let data = JSON.stringify(widget);

    let result = null;
    try {
      result = await axios.post("http://localhost:52779/api/widget/add", data, {
        headers: {
          "Content-Type": "application/json"
        }
      });
    } catch {
      return false;
    }

    if (result.status === 200) {
      return true;
    } else {
      return false;
    }
  }

  async deleteWidget(id) {
    let result = null;
    try {
      result = await axios.delete(
        `http://localhost:52779/api/widget/delete/${id}`
      );
    } catch {
      return false;
    }

    if (result.status === 200) {
      return true;
    } else {
      return false;
    }
  }
}

export default ApiWorker;
