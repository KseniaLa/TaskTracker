import { stateMap } from "../mappings/NameMapping.js";
import { colorMap } from "../mappings/ColorMappings.js";

class ChartDataProcessor {
  static getData(tasks, states, priorities, chartType, colorScheme) {
    let tasksbyPrior = tasks.filter(t => priorities.includes(t.priority));

    let colors = colorMap[colorScheme];

    states.sort();
    let labels = states.map(s => stateMap[s]);
    let backgroundColor = states.map(s => colors[s]);
    let data = states.map(s => tasksbyPrior.filter(t => t.state === s).length);

    let dataGetter = {};
    switch (chartType) {
      case 0:
        dataGetter = new ListData();
        break;
      case 1:
        dataGetter = new PieData();
        break;
      case 2:
        dataGetter = new BarData();
        break;
    }

    let dataObj = dataGetter.getData(labels, backgroundColor, data);

    let result = {
      data: dataObj,
      ids: tasksbyPrior.map(t => t.id)
    };

    return result;
  }
}

class PieData {
  getData(labels, color, data) {
    return {
      labels,
      datasets: [
        {
          label: "Lol",
          backgroundColor: color,
          data
        }
      ]
    };
  }
}

class BarData {
  getData(labels, color, data) {
    let datasets = [];
    for (let i = 0; i < labels.length; i++) {
      datasets.push({
        label: labels[i],
        backgroundColor: color[i],
        data: [data[i]]
      });
    }
    return {
      labels: ["Count"],
      datasets
    };
  }
}

class ListData {
  getData(labels, color, data) {
    let sumData = data.reduce((a, b) => a + b, 0);

    let datasets = [];
    for (let i = 0; i < labels.length; i++) {
      datasets.push({
        label: labels[i],
        backgroundColor: color[i],
        data: ((data[i] / sumData) * 100).toFixed(0)
      });
    }

    return {
      datasets
    };
  }
}

export default ChartDataProcessor;
