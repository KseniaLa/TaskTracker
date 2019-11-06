import WidgetWorker from "./WidgetWorkerInterface";
import WidgetApiWorker from "./WidgetApiWorker";
import WidgetLsWorker from "./WidgetLsWorker";

class WidgetWorkerFactory {
  constructor() {}

  getWorker(isDemo) {
    let widgetWorker = new WidgetWorker();

    if (isDemo) {
      widgetWorker.worker = new WidgetLsWorker();
    } else {
      widgetWorker.worker = new WidgetApiWorker();
    }

    return widgetWorker;
  }
}

export default WidgetWorkerFactory;
