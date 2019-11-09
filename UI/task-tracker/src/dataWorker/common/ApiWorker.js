import axios from "axios";

class ApiWorker {
  constructor() {}

  async addTask() {
    let result = await axios.get("http://localhost:52779/api/task");
    return result.data.tasks;
  }

  async getTasks() {
    let result = await axios.get("http://localhost:52779/api/task");
    return result.data.tasks;
  }

  deleteTask() {

  }

  addWidget() {

  }
}

export default ApiWorker;
