import axios from "axios";

class ApiWorker {
  constructor() {}

  addTask() {
    console.log("I request api for task!");
    axios
      .get("http://localhost:52779/api/task")
      .then(response => console.log(response));
  }

  addWidget() {
    console.log("I request api for widget!");
  }
}

export default ApiWorker;
