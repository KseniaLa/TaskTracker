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
      return { success: false };
    }

    if (result.status === 200) {
      return { success: true };
    } else {
      return { success: false };
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

    console.log(result.data);

    return { token: result.data.accessToken, success: true };
  }
}

export default AccountWorker;
