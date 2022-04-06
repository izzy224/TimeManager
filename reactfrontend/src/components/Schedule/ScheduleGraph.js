import Box from "plotly.js/lib/box";
import React, { useEffect, useState } from "react";
import Plot from "react-plotly.js";

const ScheduleGraph = ({ graphData, setSelectedScheduleId }) => {
  const [mappedData, setMappedData] = useState([
    {
      x: [],
      y: [],
      mode: "lines",
    },
  ]);
  useEffect(() => {
    let tempArray = [];
    graphData.forEach((sched) => {
      let tempDate = new Date(sched.startTime);
      let tempStartY = tempDate.getHours() + tempDate.getMinutes() / 60;
      tempDate = new Date(sched.endTime);
      let tempEndY = tempDate.getHours() + tempDate.getMinutes() / 60;
      tempArray.push({
        x: [0, 1, 2],
        y: [tempStartY, tempStartY, tempStartY],
        mode: "lines+text",
        text: ["", sched.name, ""],
        textposition: "bottom",
        type: "scatter",
        hoverinfo: "none",
        meta: [
          sched.timeScheduleId,
          sched.timeScheduleId,
          sched.timeScheduleId,
        ],
      });
      tempArray.push({
        x: [0, 1, 2],
        y: [tempEndY, tempEndY, tempEndY],
        mode: "lines+text",
        text: ["", sched.description, ""],
        textposition: "top",
        type: "scatter",
        hoverinfo: "none",
        fill: "tonexty",
        meta: [
          sched.timeScheduleId,
          sched.timeScheduleId,
          sched.timeScheduleId,
        ],
      });
    });
    setMappedData(tempArray);
  }, [graphData]);
  const onGraphClick = (data) => {
    setSelectedScheduleId(data.points[0].meta);
  };

  return (
    <>
      <Plot
        style={{ width: "inherit" }}
        onClick={onGraphClick}
        data={mappedData}
        layout={{
          showlegend: false,
          autosize: true,
          xaxis: {
            fixedrange: true,
            zeroline: false,
            visible: false,
            autorange: true,
          },
          yaxis: {
            fixedrange: true,
            zeroline: false,
            autorange: false,
            range: [24, 0],
            tickmode: "array",
            tickvals: [
              0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18,
              19, 20, 21, 22, 23, 24,
            ],
            ticktext: [
              "12AM",
              "1AM",
              "2AM",
              "3AM",
              "4AM",
              "5AM",
              "6AM",
              "7AM",
              "8AM",
              "9AM",
              "10AM",
              "11AM",
              "12PM",
              "1PM",
              "2PM",
              "3PM",
              "4PM",
              "5PM",
              "6PM",
              "7PM",
              "8PM",
              "9PM",
              "10PM",
              "11PM",
              "12PM",
            ],
          },
        }}
        config={{ displayModeBar: false }}
      />
    </>
  );
};

export default ScheduleGraph;
