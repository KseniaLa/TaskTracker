import axios from "axios";

class ApiWorker {
  constructor() {}

  addTask() {
    // console.log("I request api for task!");
    axios.get("http://localhost:52779/api/task").then(response => response);
  }

  getTasks() {
    console.log("I request api for task list");
    let tasks = [];
    return tasks;
  }

  deleteTask() {
    //console.log("I request api for task deletion");
  }

  addWidget() {
    //console.log("I request api for widget!");
  }
}

export default ApiWorker;
