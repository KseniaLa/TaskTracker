import axios from "axios";
import {
  API_BASE,
  TASK_PREFIX,
  WIDGET_PREFIX,
  ADD,
  EDIT,
  DELETE
} from "./ApiConstants.js";

class ApiWorker {
  constructor() {}

  async addTask(task, authToken) {
    let data = JSON.stringify(task);

    let action = task.id > 0 ? EDIT : ADD;

    let url = `${API_BASE}${TASK_PREFIX}${action}`;

    let result = null;
    try {
      result = await axios.post(url, data, {
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + authToken
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

  async getTasks(authToken) {
    let result = null;

    let url = `${API_BASE}${TASK_PREFIX}`;

    try {
      result = await axios.get(url, {
        headers: {
          Authorization: "Bearer " + authToken
        }
      });
    } catch {
      return { data: [], success: false };
    }

    return { data: result.data, success: true };
  }

  async deleteTask(id, authToken) {
    let result = null;

    let url = `${API_BASE}${TASK_PREFIX}${DELETE}/${id}`;

    try {
      result = await axios.delete(url, {
        Authorization: "Bearer " + authToken
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

  async getWidgets(authToken) {
    let result = null;

    let url = `${API_BASE}${WIDGET_PREFIX}`;

    try {
      result = await axios.get(url, {
        headers: {
          Authorization: "Bearer " + authToken
        }
      });
    } catch {
      return { data: [], success: false };
    }

    return { data: result.data, success: true };
  }

  async addWidget(widget, authToken) {
    let data = JSON.stringify(widget);

    let url = `${API_BASE}${WIDGET_PREFIX}${ADD}`;

    let result = null;
    try {
      result = await axios.post(url, data, {
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + authToken
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

  async deleteWidget(id, authToken) {
    let result = null;

    let url = `${API_BASE}${WIDGET_PREFIX}${DELETE}/${id}`;

    try {
      result = await axios.delete(url, {
        Authorization: "Bearer " + authToken
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
}

export default ApiWorker;
