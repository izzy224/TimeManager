import React, { useEffect, useState } from "react";
import Plot from "react-plotly.js";
const FinancePieChart = ({ date, days }) => {
  const [mappedData, setMappedData] = useState([
    {
      values: [0],
      labels: [""],
      type: "pie",
      textinfo: "label+percent",
      textposition: "outside",
    },
  ]);
  useEffect(() => {
    setMappedData([
      {
        values: [0],
        labels: [""],
        type: "pie",
        textinfo: "label+percent",
        textposition: "outside",
      },
    ]);
    fetch("api/finance/getstats", {
      method: "POST",
      headers: {
        Authorization: window.sessionStorage.getItem("token"),
        "Content-type": "application/json",
      },
      body: JSON.stringify({
        Date: new Date().toDateString(),
        LastDays: 7,
      }),
    })
      .then((response) => response.json())
      .then((data) => {
        let tempArray = [
          {
            values: [],
            labels: [],
            type: "pie",
            textinfo: "label+percent",
            textposition: "outside",
          },
        ];
        data.forEach((stat) => {
          tempArray[0].values.push(stat.amount);
          tempArray[0].labels.push(stat.name);
        });
        console.log(tempArray);
        setMappedData(tempArray);
      });
  }, [date]);
  return (
    <>
      <Plot
        data={mappedData}
        layout={{
          title: `${days > 1 ? `Last ${days} days` : "Last Day"}`,
          height: 455,
          width: 550,
          margin: { t: 90, b: 90, l: 90, r: 95 },
          showlegend: false,
          plot_bgcolor: "black",
          paper_bgcolor: "#1A202C",
          font: {
            color: "#F7F7F7",
          },
        }}
      />
    </>
  );
};

export default FinancePieChart;
