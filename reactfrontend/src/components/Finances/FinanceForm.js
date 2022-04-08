import { Tab, TabList, TabPanel, TabPanels, Tabs } from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import FinanceInsert from "./FinanceInsert";
import FinanceUpdate from "./FinanceUpdate";

const FinanceForm = ({
  date,
  walletId,
  transactions,
  setTransactions,
  selectedTransaction,
}) => {
  const [transactionCategories, setTransactionCategories] = useState([]);
  useEffect(() => {
    fetch("/api/finance/categories", {
      method: "GET",
      headers: {
        Authorization: window.sessionStorage.getItem("token"),
        "Content-type": "application/json",
      },
    })
      .then((response) => response.json())
      .then((data) => {
        setTransactionCategories(data);
      });
  }, []);

  return (
    <>
      <Tabs>
        <TabList>
          <Tab>Insert</Tab>
          <Tab>Update</Tab>
        </TabList>
        <TabPanels>
          <TabPanel>
            <FinanceInsert
              date={date}
              walletId={walletId}
              transactionCategories={transactionCategories}
              setTransactions={setTransactions}
              transactions={transactions}
            />
          </TabPanel>
          <TabPanel>
            <FinanceUpdate
              transactions={transactions}
              setTransactions={setTransactions}
              transactionCategories={transactionCategories}
              selectedTransaction={selectedTransaction}
            />
          </TabPanel>
        </TabPanels>
      </Tabs>
    </>
  );
};

export default FinanceForm;
