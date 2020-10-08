import axios from "axios";
import { API_BASE, USER, LOGIN } from "./ApiConstants.js";

class AccountWorker {
  constructor() {}

  async createUser(user) {
    let data = JSON.stringify(user);

    let url = `${API_BASE}${USER}`;

    let result = null;
    try {
      result = await axios.post(url, data, {
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

  async authenticate(credentials) {
    let data = JSON.stringify(credentials);

    let url = `${API_BASE}${USER}${LOGIN}`;

    let result = null;
    try {
      result = await axios.post(url, data, {
        headers: {
          "Content-Type": "application/json"
        }
      });
    } catch {
      return { token: null, success: false };
    }

    return { token: result.data.token, success: true };
  }
}

export default AccountWorker;
