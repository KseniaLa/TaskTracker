import axios from "axios";

class ApiWorker {
  constructor() {}

  addTask() {
    axios.get("http://localhost:52779/api/task").then(response => response);
  }

  getTasks() {
    let tasks = [];
    return tasks;
  }

  deleteTask() {

  }

  addWidget() {

  }
}

export default ApiWorker;
