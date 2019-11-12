import axios from "axios";

class ApiWorker {
  constructor() {}

  async addTask(task) {
    let data = JSON.stringify(task);

    let result = null;
    try {
      result = await axios.post("http://localhost:9000/api/task/add", data, {
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
      result = await axios.get("http://localhost:9000/api/task");
    } catch {
      return { data: [], success: false };
    }

    return { data: result.data.tasks, success: true };
  }

  async deleteTask(id) {
    let result = null;
    try {
      result = await axios.delete(
        `http://localhost:9000/api/task/delete/${id}`
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
    let result = null;
    try {
      result = await axios.get("http://localhost:9000/api/widget");
    } catch {
      return { data: [], success: false };
    }

    return { data: result.data.widgets, success: true };
  }

  async addWidget(widget) {
    let data = JSON.stringify(widget);

    let result = null;
    try {
      result = await axios.post("http://localhost:9000/api/widget/add", data, {
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
        `http://localhost:9000/api/widget/delete/${id}`
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
