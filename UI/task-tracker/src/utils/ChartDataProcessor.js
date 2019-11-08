import { stateMap } from "../mappings/NameMapping.js";

class ChartDataProcessor {
  static getData(tasks, states, priorities) {
    let tasksbyPrior = tasks.filter(t => priorities.includes(t.priority));

    let colors = {
      0: "#ff0000",
      1: "#00ff00",
      2: "#0000ff"
    };

    states.sort();
    let labels = states.map(s => stateMap[s]);
    let backgroundColor = states.map(s => colors[s]);
    let data = states.map(s => tasksbyPrior.filter(t => t.state === s).length);

    let result = {
      data: {
        labels,
        datasets: [
          {
            label: "Lol",
            backgroundColor,
            data
          }
        ]
      },
      ids: tasksbyPrior.map(t => t.id)
    };

    return result;
  }
}

export default ChartDataProcessor;
