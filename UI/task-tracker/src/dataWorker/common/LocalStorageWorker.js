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
    //console.log("I request ls for task!");
  }

  async getTasks() {
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

  addWidget(widget) {
    let widgets = [];
    if (localStorage.getItem("widgets")) {
      widgets = JSON.parse(localStorage.getItem("widgets"));
    }
    if (widget.id < 0) {
      var ids = widgets.map(function(w) {
        return w.id;
      });
      var maxId = 0;
      if (widgets.length > 0) {
        maxId = Math.max(...ids);
      }
      widget.id = ++maxId;
      widgets.push(widget);

      localStorage.setItem("widgets", JSON.stringify(widgets));
    }
  }

  getWidgets() {
    let widgets = [];
    if (localStorage.getItem("widgets")) {
      widgets = JSON.parse(localStorage.getItem("widgets"));
    }

    return widgets;
  }

  deleteWidget(id) {
    let widgets = [];
    if (localStorage.getItem("widgets")) {
      widgets = JSON.parse(localStorage.getItem("widgets"));
    }

    widgets = widgets.filter(w => w.id !== id);

    localStorage.setItem("widgets", JSON.stringify(widgets));
  }
}

export default LsWorker;
