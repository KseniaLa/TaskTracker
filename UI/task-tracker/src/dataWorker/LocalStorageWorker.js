class LsWorker {
  constructor() {}

  addTask(task) {
    let tasks = [];
    if (localStorage.getItem("tasks")) {
      tasks = JSON.parse(localStorage.getItem("tasks"));
    }
    if (task.id < 0) {
      var ids = tasks.map(function(t) {
        return t.id;
      });
      var maxId = 0;
      if (tasks.length > 0) {
        maxId = Math.max(...ids);
      }
      task.id = ++maxId;
      tasks.push(task);
    } else {
      let ix = tasks.findIndex(ts => ts.id == task.id);
      if (ix >= 0) {
        tasks[ix] = task;
      }
    }

    localStorage.setItem("tasks", JSON.stringify(tasks));
    console.log("I request ls for task!");
  }

  getTasks() {
    console.log("I request ls for task list");
    let tasks = [];
    if (localStorage.getItem("tasks")) {
      tasks = JSON.parse(localStorage.getItem("tasks"));
    }

    return tasks;
  }

  deleteTask(id) {
    let tasks = [];
    if (localStorage.getItem("tasks")) {
      tasks = JSON.parse(localStorage.getItem("tasks"));
    }

    tasks = tasks.filter(t => t.id !== id);

    localStorage.setItem("tasks", JSON.stringify(tasks));
  }

  addWidget() {
    console.log("I request ls for widget!");
  }
}

export default LsWorker;
