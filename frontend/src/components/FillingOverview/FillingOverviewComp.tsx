import {
  Button,
  Container,
  HStack,
  Spacer,
  Table,
  Tbody,
  Td,
  Text,
  Th,
  Thead,
  Tr
} from "@chakra-ui/react";
import PageIndicator from "components/Demo/components/PageIndicator";
import { usePagedFetched } from "hooks/usePagedFetched";
import React, { FC, useCallback, useMemo, useReducer, useState } from "react";
import ListReducer from "react-list-reducer";
import { genRefillClient } from "services/backend/apiClients";
import { RefillDto, TankType } from "services/backend/nswagts";
import { capitalize } from "utils/capitalizeAnyString";

import FilterTh from "./components/FilterTh";
import SortTh, { Direction } from "./components/SortTh";

type Props = {
  preLoadedData?: RefillDto[];
  preloadDataNeedle?: string;
  preloadLoadedAll?: boolean;
  preLoadedPageCount?: number;
};

export const PAGE_SHOW_SIZE = 15;

const defaultSort = (a: RefillDto, b: RefillDto) => (a.id > b.id ? 1 : -1);

const FillingOverviewComp: FC<Props> = ({
  preLoadedData = [],
  preloadDataNeedle = "0",
  preloadLoadedAll = false
}) => {
  const [data, dataDispatch] = useReducer(ListReducer<RefillDto>("id"), preLoadedData);
  const [pageShowing, setPageShowing] = useState(0);

  const { done } = usePagedFetched(
    "createdAt",
    (needle, size) => genRefillClient().then(client => client.get(needle, size)),
    dataDispatch,
    {
      autoStart: !preloadLoadedAll,
      initialNeedle: preloadDataNeedle,
      pageSize: PAGE_SHOW_SIZE
    }
  );

  const pages = useMemo(() => {
    const maxDataLength = data.length;
    const allPageMax = maxDataLength > 0 ? Math.ceil(maxDataLength / PAGE_SHOW_SIZE) : 0;

    return [...new Array(allPageMax)].map((x, i) => i);
  }, [data, done]);

  /**
   * Splits the data into table pages.
   */
  const dataSplitter = useMemo<RefillDto[]>(() => {
    const realPageMax = data.length > 0 ? Math.ceil(data.length / PAGE_SHOW_SIZE) : 0;

    if (realPageMax === 0) {
      return [];
    }

    const realDataOnCurrentPage = data.slice(
      pageShowing * PAGE_SHOW_SIZE,
      (pageShowing + 1) * PAGE_SHOW_SIZE
    );
    return realDataOnCurrentPage;
  }, [data, pageShowing]);

  const elementsOnLastPage = useMemo(() => {
    const elements = data.slice((pages.length - 1) * PAGE_SHOW_SIZE, pages.length * PAGE_SHOW_SIZE);
    return elements.length;
  }, [pages, data]);

  const [sort, setSort] = useState<(a: RefillDto, b: RefillDto) => number>(() => defaultSort);

  const sortCb = useCallback((key: keyof RefillDto, direction: Direction) => {
    if (direction === null) {
      setSort(() => defaultSort);
      return;
    }

    const sortVal = direction === "ASC" ? 1 : -1;
    setSort(() => (a: RefillDto, b: RefillDto) => (a[key] > b[key] ? sortVal : -sortVal));
  }, []);

  return (
    <Container minW="4xl">
      <Table variant="striped" colorScheme="black" size="md" w="100%">
        <Thead>
          <Tr>
            <Th>
              <HStack spacing={0}>
                <Text>Type</Text>
                <Spacer w={2} />
                <SortTh queryKey="locationType" sortCb={sortCb} />
                <FilterTh
                  queryKey="locationType"
                  options={[
                    { id: "1", name: "test1" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "2", name: "test2" },
                    { id: "3", name: "test3" }
                  ]}
                  filterCb={(a, b) => console.log(a, b)}
                />
              </HStack>
            </Th>
            <Th>
              <HStack>
                <Text>Date</Text>
                <SortTh queryKey="actualDeliveryDate" sortCb={sortCb} />
              </HStack>
            </Th>
            <Th>
              <HStack>
                <Text>Truck ID</Text>
                <SortTh queryKey="truckId" sortCb={sortCb} />
              </HStack>
            </Th>
            <Th>
              <HStack>
                <Text>Start</Text>
                <SortTh queryKey="startAmount" sortCb={sortCb} />
              </HStack>
            </Th>
            <Th>
              <HStack>
                <Text>End</Text>
                <SortTh queryKey="endAmount" sortCb={sortCb} />
              </HStack>
            </Th>
            <Th>Coupon</Th>
          </Tr>
        </Thead>
        <Tbody>
          {dataSplitter.sort(sort).map(data => {
            return (
              <Tr key={data.id}>
                <Td>{capitalize(TankType[data.locationType])}</Td>
                <Td>{new Date(data.actualDeliveryDate).toLocaleDateString()}</Td>
                <Td>{data.truckId}</Td>
                <Td isNumeric>{data.startAmount}</Td>
                <Td isNumeric>{data.endAmount}</Td>
                <Td>{data.couponId}</Td>
              </Tr>
            );
          })}
        </Tbody>
      </Table>

      <PageIndicator activePage={pageShowing} onClickPage={setPageShowing} pages={pages}>
        {!done && elementsOnLastPage >= PAGE_SHOW_SIZE && (
          <Button colorScheme="blue" size="sm" variant="outline"></Button>
        )}
      </PageIndicator>
    </Container>
  );
};

export default FillingOverviewComp;
