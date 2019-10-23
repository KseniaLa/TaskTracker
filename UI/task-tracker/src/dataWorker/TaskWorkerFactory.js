import { TaskWorker } from "./TaskWorkerInterface";
import { TaskApiWorker } from "./TaskApiWorker";
import { TaskLsWorker } from "./TaskLsWorker";

class TaskWorkerFactory {
  constructor() {}

  getWorker(isDemo) {
    let taskWorker = new TaskWorker();

    if (isDemo) {
      taskWorker.worker = new TaskLsWorker();
    } else {
      taskWorker.worker = new TaskApiWorker();
    }

    return taskWorker;
  }
}

export default TaskWorkerFactory;
